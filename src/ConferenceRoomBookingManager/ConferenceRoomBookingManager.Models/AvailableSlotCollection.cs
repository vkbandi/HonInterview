using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConferenceRoomBookingManager.Models
{
    public class AvailableSlotCollection : List<AvailableSlot>
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if(this.Any())
            {
                foreach(var item in this)
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString();
        }
    }
}
