using UnityEngine;

namespace Core.Input
{
    public class PlayerInputHandler
    {
        public Vector2 TouchBeginPos;
        public Vector2 TouchEndPos;
        public Vector2 TouchDelta => TouchEndPos - TouchBeginPos;
        
        public void Tick()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                TouchBeginPos = UnityEngine.Input.mousePosition;
                TouchEndPos = UnityEngine.Input.mousePosition;
            }

            if (UnityEngine.Input.GetMouseButton(0))
            {
                TouchEndPos  = UnityEngine.Input.mousePosition;
            }

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                TouchEndPos = UnityEngine.Input.mousePosition;
            }
        }
    }
}
