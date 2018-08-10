using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.Media;
using AudioManager.Droid;
using AudioManager.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidAudioManager))]
namespace AudioManager.Droid
{
    class DroidAudioManager : IAudioManager
    {
        #region Private Variables

        private readonly Dictionary<string, int> _sounds = new Dictionary<string, int>();

        private readonly SoundPool _soundPool;

        private MediaPlayer _backgroundMusic;
        private string _backgroundSong = "";

        //This is needed for iOS and Andriod because they do not await loading music
        private bool _backgroundMusicLoading;

        private bool _musicOn = true;
        private float _backgroundMusicVolume = 0.5f;

        #endregion

        #region Computed Properties

        public float BackgroundMusicVolume
        {
            get
            {
                return _backgroundMusicVolume;
            }
            set
            {
                _backgroundMusicVolume = value;

                _backgroundMusic?.SetVolume(_backgroundMusicVolume, _backgroundMusicVolume);
            }
        }

        public bool MusicOn
        {
            get { return _musicOn; }
            set
            {
                _musicOn = value;

                if (!MusicOn)
                    SuspendBackgroundMusic();
                else
#pragma warning disable 4014
                    RestartBackgroundMusic();
#pragma warning restore 4014

            }
        }

        public bool LoopMusic { get; set; } = false;

        public int MaxLoops { get; set; } = 0;

        public bool EffectsOn { get; set; } = true;

        public float EffectsVolume { get; set; } = 1.0f;

        public string SoundPath { get; set; } = "Sounds";
        #endregion

        #region Constructors

        public DroidAudioManager()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                // Do things the Lollipop way
                var attributes = new AudioAttributes.Builder()
                .SetUsage(AudioUsageKind.Game)
                .SetContentType(AudioContentType.Music)
                .Build();

                _soundPool = new SoundPool.Builder()
                    .SetAudioAttributes(attributes)
                    .SetMaxStreams(10)
                    .Build();
            }
            else
            {
                // Do things the pre-Lollipop way
                _soundPool = new SoundPool(10, Android.Media.Stream.Music, 0);
            }

            //6, Stream.Music, 0


            // Initialize
            ActivateAudioSession();
        }

        #endregion

        #region Public Methods

        public void ActivateAudioSession()
        {
            //todo
        }

        public void DeactivateAudioSession()
        {
            _soundPool.AutoPause();
            _backgroundMusic.Pause();
        }

        public void ReactivateAudioSession()
        {
            _soundPool.AutoResume();
            RestartBackgroundMusic();
        }

        public async Task<bool> PlayBackgroundMusic(string filename)
        {
            // Music enabled?
            if (!MusicOn || _backgroundMusicLoading) return false;

            _backgroundMusicLoading = true;

            // Any existing background music?
            _backgroundMusic?.Stop();

            _backgroundSong = filename;

            // Initialize background music
            try
            {
                string filePath = Path.Combine(SoundPath, filename);
                var afd = Forms.Context.Assets.OpenFd(filePath);
                _backgroundMusic = new MediaPlayer();
                _backgroundMusic.SetVolume(BackgroundMusicVolume, BackgroundMusicVolume);
                _backgroundMusic.Looping = LoopMusic;
                _backgroundMusic.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                _backgroundMusic.Prepare();
                _backgroundMusic.Start();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            _backgroundMusicLoading = false;

            return _backgroundMusic != null;
        }

        public void StopBackgroundMusic()
        {
            // If any background music is playing, stop it
            _backgroundSong = "";
            _backgroundMusicLoading = false;
            _backgroundMusic?.Stop();
        }

        public void SuspendBackgroundMusic()
        {
            // If any background music is playing, stop it
            _backgroundMusic?.Stop();
        }

        public async Task<bool> RestartBackgroundMusic()
        {
            // Music enabled?
            if (!EffectsOn) return false;

            // Was a song previously playing?
            if (_backgroundSong == "") return false;

            // Restart song to fix issue with wonky music after sleep
            return await PlayBackgroundMusic(_backgroundSong);
        }

        public async Task<bool> PlaySound(string filename)
        {
            // Music enabled?
            if (!MusicOn) return false;

            var effectId = await NewSound(filename, EffectsVolume);
            //_soundEffects.Add(effectId);

            return effectId != 0;
        }

        private async Task<int> NewSound(string filename, float defaultVolume, int priority = 0, bool isLooping = false)
        {
            try
            {
                if (!_sounds.ContainsKey(filename))
                {
                    var file = Forms.Context.Assets.OpenFd(Path.Combine(SoundPath, filename));
                    var soundId = await _soundPool.LoadAsync(file, priority);
                    if (soundId == 0)
                        return 0;
                    _sounds.Add(filename, soundId);
                }

                return _soundPool.Play(_sounds[filename], defaultVolume, defaultVolume, priority, LoopMusic ? MaxLoops : 0, 1f);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return 0;
        }

        #endregion
    }
}