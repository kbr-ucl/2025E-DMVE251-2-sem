using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Booking.Domain.Entity
{
    public class Booking
    {
        public DateTime StartTid { get; private set; }
        public DateTime SlutTid { get; private set; }
        public Kunde Kunde { get; private set; }

        public Booking(DateTime start, DateTime slut, Kunde kunde)
        {
            TimesIsValid(start);
            NoOverlap(start, slut);

            Kunde = kunde;
            StartTid = start;
            SlutTid = slut;
        }

        public void UpdateStartSlut(DateTime start, DateTime slut)
        {
            TimesIsValid(start);
            TimesIsValid(StartTid);
            NoOverlap(start, slut);

            StartTid = start;
            SlutTid = slut;
        }

        private void TimesIsValid(DateTime start)
        {
            if (DateTime.Now > start) throw new Exception("Booking is in the past");
        }

        //En Booking må ikke overlappende andre bookinger.
        private void NoOverlap(DateTime start, DateTime slut)
        {

        }

    }
}
