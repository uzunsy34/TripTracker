using System;
using System.Collections.Generic;
using System.Linq;

namespace TripTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
        {
            new Trip{
                Id =1,
                Name="MVP Summit",
                StartDate=new DateTime(2019,7,9),
                EndDate=new DateTime(2019,7,12)

            },
             new Trip{
                Id =2,
                Name="DevIntersection Orlando 2019",
                StartDate=new DateTime(2019,7,25),
                EndDate=new DateTime(2019,7,27)

            },
               new Trip{
                Id =3,
                Name="Build 2019",
                StartDate=new DateTime(2019,9,7),
                EndDate=new DateTime(2019,9,7)

            }

        };
        public List<Trip> Get()
        {
            return MyTrips;
        }
        public Trip Get(int id)
        {
            return MyTrips.First(k => k.Id == id);
        }
        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }
        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
        }
        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
