using Microsoft.Xna.Framework;


namespace SpriteSlicer.src
{
    public static class Time
    {
        public static float Fps { get; private set; }
        public static float DeltaTime { get; private set; }
        public static GameTime GameTime { get; private set; }

        public static void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            Fps = (float)(1 / gameTime.ElapsedGameTime.TotalSeconds);
            //DeltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.01f;
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Returns FPS as a string (used by Stats.cs)
        /// </summary>
        /// <returns></returns>
        public static string GetFps_String()
        {
            return Fps.ToString();
        }

        /// <summary>
        /// Returns Delta as a string (used by Stats.cs)
        /// </summary>
        /// <returns></returns>
        public static string GetDeltaTime_String()
        {
            return DeltaTime.ToString();
        }
    }
}


