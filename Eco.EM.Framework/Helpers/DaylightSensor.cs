namespace Eco.EM.Framework.Helpers
{
    using Eco.Shared.Time; //Added Time items were moved to this using making it required
    using Eco.Shared.Utils;
    using Eco.Simulation;
    using Eco.Simulation.Time;

    public static class DaylightSensorHelper
    {
        public static bool IsDayLight( int DayTime = 5, int NightTime = 19 )
        {
            double num = TimeUtil.SecondsToHours( ( ( WorldTime.Seconds * Singleton<EcoSim>.Obj.EcoDef.TimeOfDayScale ) + 28800.0 ) % 86400.0 );
            return ( ( num >= DayTime ) && ( num < NightTime ) );
        }
    }
}
