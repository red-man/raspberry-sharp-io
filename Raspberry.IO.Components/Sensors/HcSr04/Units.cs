namespace Raspberry.IO.Components.Sensors.HcSr04
{
    internal static class Units
    {
        public static class Velocity
        {
            public static class Sound
            {
                public static decimal ToDistance(decimal time)
                {
                    if (time == decimal.MinValue)
                        return decimal.MinValue;

                    return (time/1000m)*340/2;
                }
            }
        }
    }
}