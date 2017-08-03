using System;
using _09.Traffic_Lights.Enums;

namespace _09.Traffic_Lights
{
    public class TrafficLight
    {
        private LightColor colorState;

        public TrafficLight(LightColor colorState)
        {
            this.colorState = colorState;
        }

        public void ChangeState()
        {
            this.colorState = (LightColor)(((int)this.colorState + 1)
                                           % Enum.GetNames(typeof(LightColor)).Length);
        }

        public override string ToString()
        {
            return this.colorState.ToString();
        }
    }
}