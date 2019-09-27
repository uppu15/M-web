using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MWeb1_2.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Markers.Any())
            {
                context.Markers.AddRange(
                    new Marker
                    {
                        userID = 1,
                        markerID = "qwer1",
                        markerLat = 32.818609,
                        markerLng = -117.143261
                    },
                    new Marker
                    {
                        userID = 1,
                        markerID = "asdf2",
                        markerLat = 32.824632,
                        markerLng = -117.126781
                    },
                    new Marker
                    {
                        userID = 2,
                        markerID = "zxcv3",
                        markerLat = 32.810314,
                        markerLng = -117.131116
                    },
                    new Marker
                    {
                        userID = 3,
                        markerID = "qazwsx1",
                        markerLat = 32.815320,
                        markerLng = -117.13532
                    },
                    new Marker
                    {
                        userID = 3,
                        markerID = "Embry-Riddle",
                        markerLat = 32.819563,
                        markerLng = -117.140984
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
