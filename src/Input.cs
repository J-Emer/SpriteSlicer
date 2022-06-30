using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpriteSlicer.src
{
    public static class Input
    {
        private static KeyboardState pKeys;
        private static KeyboardState cKeys;

        private static MouseState pMouse;
        private static MouseState cMouse;

        public static string InputString { get; private set; }

        public static Vector2 MousePosition
        {
            get
            {
                return new Vector2(cMouse.Position.X, cMouse.Position.Y);
            }
        }

        private static int pScroll;
        private static int cScroll;


        /// <summary>
        /// Returns a float between -1, 1 for the x Axis (A,D keys)
        /// </summary>
        public static float xAxis { get; private set; }

        /// <summary>
        /// Returns a float between -1, 1 for the y Axis (W,S keys)
        /// </summary>
        public static float yAxis { get; private set; }


        public static void Update()
        {
            pKeys = cKeys;
            cKeys = Keyboard.GetState();

            //InputString = cKeys.GetPressedKeys().ToString();

            pMouse = cMouse;
            cMouse = Mouse.GetState();

            pScroll = cScroll;
            cScroll = cMouse.ScrollWheelValue;

            InputString = "";

            foreach (var item in cKeys.GetPressedKeys())
            {
                if (GetKeyDown(item))
                {
                    InputString += item.ToString();
                }
            }

            HandleAxis();
        }

        private static void HandleAxis()
        {
            if (GetKey(Keys.W) || GetKey(Keys.Up))
            {
                yAxis -= Time.DeltaTime;
            }
            else if (GetKey(Keys.S) || GetKey(Keys.Down))
            {
                yAxis += Time.DeltaTime;
            }
            else
            {
                yAxis = 0f;
            }



            if (GetKey(Keys.A) || GetKey(Keys.Left))
            {
                xAxis -= Time.DeltaTime;
            }
            else if (GetKey(Keys.D) || GetKey(Keys.Right))
            {
                xAxis += Time.DeltaTime;
            }
            else
            {
                xAxis = 0f;
            }

            xAxis = MathHelper.Clamp(xAxis, -1f, 1f);
            yAxis = MathHelper.Clamp(yAxis, -1f, 1f);
        }

        /// <summary>
        /// Returns true/false if a key is currently being pressed down
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public static bool GetKey(Keys _key)
        {
            if (cKeys.IsKeyDown(_key))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true/false if key is currently being pressed this frame
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public static bool GetKeyDown(Keys _key)
        {
            if (cKeys.IsKeyDown(_key) && (!pKeys.IsKeyDown(_key)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true/false if a key is currently being released this frame
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public static bool GetKeyUp(Keys _key)
        {
            if (cKeys.IsKeyUp(_key) && (!pKeys.IsKeyUp(_key)))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Returns true/false if a mouse button is being held down 
        /// LMB = 0, RMB = 1, MMB = 2
        /// </summary>
        /// <param name="_index"></param>
        /// <returns></returns>
        public static bool GetMouseButton(int _index)
        {
            if (cMouse.LeftButton == ButtonState.Pressed && pMouse.LeftButton == ButtonState.Pressed && _index == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Pressed && pMouse.RightButton == ButtonState.Pressed && _index == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Pressed && pMouse.MiddleButton == ButtonState.Pressed && _index == 2)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true/false if a mouse button is being pressed this frame 
        /// LMB = 0, RMB = 1, MMB = 2
        /// </summary>
        /// <param name="_index"></param>
        /// <returns></returns>
        public static bool GetMouseButtonDown(int _index)
        {
            if (cMouse.LeftButton == ButtonState.Pressed && pMouse.LeftButton != ButtonState.Pressed && _index == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Pressed && pMouse.RightButton != ButtonState.Pressed && _index == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Pressed && pMouse.MiddleButton != ButtonState.Pressed && _index == 2)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true/false if a mouse button is being released this frame 
        /// LMB = 0, RMB = 1, MMB = 2
        /// </summary>
        /// <param name="_index"></param>
        /// <returns></returns>
        public static bool GetMouseButtonUp(int _index)
        {
            if (cMouse.LeftButton == ButtonState.Released && pMouse.LeftButton != ButtonState.Released && _index == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Released && pMouse.RightButton != ButtonState.Released && _index == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Released && pMouse.MiddleButton != ButtonState.Released && _index == 2)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a float between -1 and 1 based on scroll wheel scrolling
        /// </summary>
        /// <returns></returns>
        public static float ScrollWheel()
        {
            if (cScroll < pScroll)
            {
                return -1;
            }

            if (cScroll > pScroll)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Returns the mouse as a rectangle in screen space
        /// </summary>
        /// <returns>new Rectangle(MousePosition.X, MousePosition.Y, 1, 1)</returns>
        public static Rectangle GetMouseRect()
        {
            return new Rectangle((int)MousePosition.X, (int)MousePosition.Y, 1, 1);
        }


        public static string MousePos_String()
        {
            return MousePosition.ToString();
        }

    }
}


