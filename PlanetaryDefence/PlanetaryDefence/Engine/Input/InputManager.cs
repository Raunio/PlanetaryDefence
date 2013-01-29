using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace PlanetaryDefence.Engine.Input
{
    /// <summary>
    /// Handles all user input and touch controls.
    /// </summary>
    public static class InputManager
    {
        private static Vector2 touchPosition;

        public static Vector2 TouchPosition
        {
            get
            {
                return touchPosition;
            }
        }

        public static TouchLocationState TouchState
        {
            get;
            private set;
        }

        public static void HandleTouchScreenInputs()
        {
            TouchCollection touchCollection = TouchPanel.GetState();

            foreach (TouchLocation touchLoc in touchCollection)
            {
                if ((touchLoc.State == TouchLocationState.Pressed) || (touchLoc.State == TouchLocationState.Moved))
                {
                    touchPosition = touchLoc.Position;
                }

                TouchState = touchLoc.State;
            }
        }
    }
}
