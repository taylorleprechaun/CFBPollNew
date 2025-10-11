using CFBPoll.System.Modules.Default;
using CFBPoll.System.Modules.Interfaces;

namespace CFBPoll.System.Modules.Factories
{
    public class RatingFactory
    {
        /// <summary>
        /// Gets the rating module for the program through an interface
        /// </summary>
        /// <param name="season">The season for the rating module</param>
        /// <param name="week">The week for the rating module</param>
        /// <returns>A module that implements the IRating interface</returns>
        public static IRatingModule GetRatingModule(int season)
        {
            switch (season)
            {
                //case var _ when season == 2024:
                //    return new TestRatingModule(season, week);
                default:
                    return new DefaultRatingModule();
            };

            //No plans for it but if for some reason in the future I want to switch to a new/different rating module then
            //I'll have to flesh out this code to switch depending on whatever conditions I choose. For now we just need
            //to return the only existing module that implements IRating
            //return new RatingModule(season, week);
        }
    }
}