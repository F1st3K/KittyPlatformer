using UnityEngine;
using UnityEngine.EventSystems;

namespace JoysticScripts.Joysticks
{
    public class FloatingJoystick : Joystick
    {
        private Vector3 Center;
        protected override void Start()
        {
            base.Start();
            Center = background.anchoredPosition;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            background.anchoredPosition = Center;
        }
    }
}