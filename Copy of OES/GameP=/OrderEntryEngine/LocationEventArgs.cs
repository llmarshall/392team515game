using OrderEntryEngine.Models;

namespace OrderEntryEngine
{
    /// <summary>
    /// the class used to represent the location event arguments
    /// </summary>
    public class LocationEventArgs
    {
        /// <summary>
        /// initialzes a new instance.
        /// </summary>
        /// <param name="location">the passed in location.</param>
        public LocationEventArgs(Location location)
        {
            Location = location;
        }

        /// <summary>
        /// gets or private sets the location.
        /// </summary>
        public Location Location { get; private set; }
    }
}
