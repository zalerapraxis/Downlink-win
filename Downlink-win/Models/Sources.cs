using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downlink_win
{
    public class Url
    {
        public string tiny { get; set; }
        public string small { get; set; }
        public string large { get; set; }
        public string full { get; set; }
    }

    public class Source
    {
        public string name { get; set; }
        public string spacecraft { get; set; }
        public int interval { get; set; }
        public double aspectratio { get; set; }
        public Url url { get; set; }
    }

    public class Sources
    {
        public List<Source> sources = new List<Source>()
        {
            new Source()
            {
                name = "GOES-East Full Disk",
                spacecraft = "GOES-East",
                interval = 600,
                aspectratio = 1,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/FD/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/FD/GEOCOLOR/678x678.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/FD/GEOCOLOR/5424x5424.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/FD/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "GOES-West Full Disk",
                spacecraft = "GOES-West",
                interval = 600,
                aspectratio = 1,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/FD/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/FD/GEOCOLOR/678x678.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/FD/GEOCOLOR/5424x5424.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/FD/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "Himawari-8 Full Disk",
                spacecraft = "Himawari-8",
                interval = 600,
                aspectratio = 1,
                url = new Url()
                {
                    tiny = "http://rammb.cira.colostate.edu/ramsdis/online/images/thumb/himawari-8/full_disk_ahi_true_color.jpg",
                    small = "http://rammb.cira.colostate.edu/ramsdis/online/images/latest/himawari-8/full_disk_ahi_true_color.jpg",
                    large = "http://rammb.cira.colostate.edu/ramsdis/online/images/latest_hi_res/himawari-8/full_disk_ahi_true_color.jpg",
                    full = "http://rammb.cira.colostate.edu/ramsdis/online/images/latest_hi_res/himawari-8/full_disk_ahi_true_color.jpg"
                }
            },
            new Source()
            {
                name = "Continental US",
                spacecraft = "GOES-East",
                interval = 300,
                aspectratio = 1.667,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/CONUS/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/CONUS/GEOCOLOR/625x375.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/CONUS/GEOCOLOR/5000x3000.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/CONUS/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "Tropical Atlantic",
                spacecraft = "GOES-East",
                interval = 600,
                aspectratio = 1.667,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/taw/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/taw/GEOCOLOR/900x540.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/taw/GEOCOLOR/3600x2160.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/taw/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "Tropical Pacific",
                spacecraft = "GOES-West",
                interval = 600,
                aspectratio = 1.667,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/tpw/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/tpw/GEOCOLOR/900x540.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/tpw/GEOCOLOR/3600x2160.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/tpw/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "US West Coast",
                spacecraft = "GOES-West",
                interval = 600,
                aspectratio = 1.667,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/CONUS/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/CONUS/GEOCOLOR/625x375.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/CONUS/GEOCOLOR/5000x3000.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/CONUS/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "Northern Pacific",
                spacecraft = "GOES-West",
                interval = 600,
                aspectratio = 1.667,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/np/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/np/GEOCOLOR/900x540.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/np/GEOCOLOR/7200x4320.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES17/ABI/SECTOR/np/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "Northern South America", 
                spacecraft = "GOES-East",
                interval = 600,
                aspectratio = 1.667,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/nsa/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/nsa/GEOCOLOR/900x540.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/nsa/GEOCOLOR/3600x2160.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/nsa/GEOCOLOR/latest.jpg"
                }
            },
            new Source()
            {
                name = "Southern South America",
                spacecraft = "GOES-East",
                interval = 600,
                aspectratio = 1.667,
                url = new Url()
                {
                    tiny = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/ssa/GEOCOLOR/thumbnail.jpg",
                    small = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/ssa/GEOCOLOR/900x540.jpg",
                    large = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/ssa/GEOCOLOR/3600x2160.jpg",
                    full = "https://cdn.star.nesdis.noaa.gov/GOES16/ABI/SECTOR/ssa/GEOCOLOR/latest.jpg"
                }
            }
        };
    }
}
