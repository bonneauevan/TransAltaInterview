using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TransAltaInterview.Models
{
    public class WeatherNetworkReport
    {
        public Obs obs { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Sterm sterm { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Lterm lterm { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Sevendays sevendays { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Fourteendays fourteendays { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Reports reports { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Swo swo { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Bug bug { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Nightsky nightsky { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Daysky daysky { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string type { get; set; }
        public string code { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    }
    public class Obs
    {
        public string lbl_updatetime { get; set; }
        public string updatetime { get; set; }
        public string updatetime_stamp_gmt { get; set; }
        public string icon { get; set; }
        public string background { get; set; }
        public string image_url { get; set; }
        public string knot_unit { get; set; }
        public int windSpeed_knot { get; set; }
        public int windGustSpeed_knot { get; set; }
        public string sunrise_time { get; set; }
        public string sunrise_time_number { get; set; }
        public string sunrise_time_AM { get; set; }
        public int sunrise_gmt { get; set; }
        public string sunset_time { get; set; }
        public string sunset_time_number { get; set; }
        public string sunset_time_PM { get; set; }
        public int sunset_gmt { get; set; }
        public bool sunrisesunset_flag { get; set; }
        public object altpc { get; set; }
        public string pollen_level_icon { get; set; }
        public string ceiling_f_icon { get; set; }
        public string uv_level_icon { get; set; }
        public string windDirection_icon { get; set; }
        public string humidity_icon { get; set; }
        public string visibility_icon { get; set; }
        public string pressure_icon { get; set; }
        public string placecode { get; set; }
        public bool aq_exists { get; set; }
        public string aq_index { get; set; }
        public string aq_level { get; set; }
        public string aq_classname { get; set; }
        public string aq_classtype { get; set; }
        public string uv_exists { get; set; }
        public string last_uv { get; set; }
        public string uv_index { get; set; }
        public string uv_label { get; set; }
        public string uv_class { get; set; }
        public bool pollen_exists { get; set; }
        public string pollen_index { get; set; }
        public string pollen_level { get; set; }
        public string pollen_name { get; set; }
        public string pollen_adlevel { get; set; }
        public string wx { get; set; }
        public string wxc { get; set; }
        public string wxca { get; set; }
        public string wxsp { get; set; }
        public string p { get; set; }
        public string pt { get; set; }
        public string pu { get; set; }
        public string wd { get; set; }
        public string wk { get; set; }
        public string w { get; set; }
        public string wu { get; set; }
        public string wg { get; set; }
        public string wgu { get; set; }
        public string t { get; set; }
        public string f { get; set; }
        public string h { get; set; }
        public string tc { get; set; }
        public string fc { get; set; }
        public string pk { get; set; }
        public string vk { get; set; }
        public string v { get; set; }
        public string vu { get; set; }
        public string ce { get; set; }
        public string ceu { get; set; }
        public string tu { get; set; }
    }

    public class Period
    {
        public string n { get; set; }
        public string period { get; set; }
        public string icon { get; set; }
        public string dewpt_c { get; set; }
        public string pressure_mb { get; set; }
        public string feelsLikeNight_unit { get; set; }
        public string dewpt_unit { get; set; }
        public string dewpt { get; set; }
        public string stperiodforday { get; set; }
        public string stperiodfortime { get; set; }
        public string stperiodforcurrent_alt { get; set; }
        public string sttimeforcurrent { get; set; }
        public string stdayforcurrent { get; set; }
        public string stperiodwithoutday { get; set; }
        public int stperioddayofweek { get; set; }
        public string rain_org { get; set; }
        public bool rain_unitflag { get; set; }
        public bool snow_unitflag { get; set; }
        public string rain_value { get; set; }
        public string snow_value { get; set; }
        public object tsl { get; set; }
        public int tc { get; set; }
        public int fc { get; set; }
        public string h { get; set; }
        public string pp { get; set; }
        public string wd { get; set; }
        public string wk { get; set; }
        public string wgk { get; set; }
        public string r { get; set; }
        public string s { get; set; }
        public string rr { get; set; }
        public string sr { get; set; }
        public string tu { get; set; }
        public string fu { get; set; }
        public string tmu { get; set; }
        public string tmau { get; set; }
        public string t { get; set; }
        public string f { get; set; }
        public string w { get; set; }
        public string wu { get; set; }
        public string wg { get; set; }
        public string wgu { get; set; }
        public string ru { get; set; }
        public string su { get; set; }
        public string tstl { get; set; }
        public string stpfc { get; set; }
        public string it { get; set; }
        public string ii { get; set; }
        public string ic { get; set; }
        public string wx { get; set; }
        public string wxc { get; set; }
        public string b { get; set; }
        public double p { get; set; }
        public string pu { get; set; }
        public int rf { get; set; }
        public int sf { get; set; }
        public string sun_hrs { get; set; }
        public string windDirectionNight { get; set; }
        public string windSpeedNight_kmh { get; set; }
        public string gust_kmh { get; set; }
        public string gustNight_kmh { get; set; }
        public string feelsLikeNight_c { get; set; }
        public string windSpeedNight { get; set; }
        public string windSpeedNight_unit { get; set; }
        public string gust_unit { get; set; }
        public string gustNight_unit { get; set; }
        public string feelsLikeNight { get; set; }
        public string sun_hours { get; set; }
        public string orig_rain { get; set; }
        public string orig_snow { get; set; }
        public string cdate { get; set; }
        public string super_short_dayanddate { get; set; }
        public string super_short_day { get; set; }
        public string super_short_date { get; set; }
        public string dotw { get; set; }
        public bool is_french { get; set; }
        public string dayLong { get; set; }
        public string rainDay { get; set; }
        public string snowDay { get; set; }
        public string rainNight { get; set; }
        public string snowNight { get; set; }
        public int imperial_temperatureMax { get; set; }
        public string imperial_temperatureMax_unit { get; set; }
        public string metric_temperatureMax_unit { get; set; }
        public int imperial_feelsLike { get; set; }
        public string metric_feelsLike { get; set; }
        public string imperial_feelsLike_unit { get; set; }
        public string metric_feelsLike_unit { get; set; }
        public int imperial_temperatureMin { get; set; }
        public string imperial_temperatureMin_unit { get; set; }
        public string metric_temperatureMin_unit { get; set; }
        public string imperial_rain { get; set; }
        public string metric_rain { get; set; }
        public string imperial_rain_value { get; set; }
        public string metric_rain_value { get; set; }
        public string imperial_snow { get; set; }
        public string metric_snow { get; set; }
        public string imperial_snow_value { get; set; }
        public string metric_snow_value { get; set; }
        public bool rainDay_unitflag { get; set; }
        public bool snowDay_unitflag { get; set; }
        public bool rainNight_unitflag { get; set; }
        public bool snowNight_unitflag { get; set; }
        public int imperial_windSpeed { get; set; }
        public string metric_windSpeed { get; set; }
        public int imperial_windGust { get; set; }
        public int imperial_windGustNight { get; set; }
        public string windGust { get; set; }
        public string windGustNight { get; set; }
        public string windGustConveted { get; set; }
        public string windGustNightConveted { get; set; }
        public string imperial_windSpeed_unit { get; set; }
        public string metric_windSpeed_unit { get; set; }
        public string metric_rain_unit { get; set; }
        public string imperial_rain_unit { get; set; }
        public string metric_snow_unit { get; set; }
        public string imperial_snow_unit { get; set; }
        public bool show_rain { get; set; }
        public int show_snow { get; set; }
        public string rainDay_range { get; set; }
        public string rainNight_range { get; set; }
        public string snowDay_range { get; set; }
        public string snowNight_range { get; set; }
        public string ida { get; set; }
        public int tmic { get; set; }
        public int tmac { get; set; }
        public string pdp { get; set; }
        public string ini { get; set; }
        public string pnp { get; set; }
        public string tm { get; set; }
        public string tma { get; set; }
        public string g { get; set; }
        public string gn { get; set; }
        public string sd { get; set; }
        public string ms { get; set; }
        public string itd { get; set; }
        public string iid { get; set; }
        public string icd { get; set; }
        public string wxd { get; set; }
        public string itn { get; set; }
        public string iin { get; set; }
        public string icn { get; set; }
        public string wxn { get; set; }
        public string daynameLong { get; set; }
        public string day { get; set; }
        public string monthLong { get; set; }
        public string monthNumber { get; set; }
        public string daytype { get; set; }
        public string imperial_rain_no_unit { get; set; }
        public string metric_rain_no_unit { get; set; }
        public string imperial_snow_no_unit { get; set; }
        public string metric_snow_no_unit { get; set; }
        public string rain_no_unit { get; set; }
        public string snow_no_unit { get; set; }
        public bool showrainunit { get; set; }
        public bool showsnowunit { get; set; }
        public string date_super_super_short { get; set; }
        public string dn { get; set; }
        public bool? hide_rain_flag { get; set; }
        public bool? hide_snow_flag { get; set; }
        public string hour { get; set; }
        public int cloud_coverage { get; set; }
        public string cc_class { get; set; }
    }

    public class Sterm
    {
        public List<Period> periods { get; set; }
        public int popflag { get; set; }
        public int gustflag { get; set; }
        public int windgustflag { get; set; }
        public string wind_unit { get; set; }
        public string rainsummary { get; set; }
        public string snow_summary { get; set; }
        public string rainsummary_short { get; set; }
        public string snowsummary_short { get; set; }
        public string precip_outlook_summary { get; set; }
        public string isRain { get; set; }
        public string isSnow { get; set; }
        public string noRainSnow { get; set; }
        public int wx_cond_long_flag { get; set; }
        public int rf { get; set; }
        public int sf { get; set; }
        public double ra { get; set; }
        public double sa { get; set; }
        public string ss { get; set; }
    }

    public class Lterm
    {
        public int tempmax_day5 { get; set; }
        public string sat_temp { get; set; }
        public string sat_cond { get; set; }
        public string sun_temp { get; set; }
        public string sun_cond { get; set; }
        public int wx_cond_long_flag { get; set; }
        public int wx_cond_long_flag_night { get; set; }
        public double ra { get; set; }
        public double sa { get; set; }
    }

    public class Sevendays
    {
        public List<Period> periods { get; set; }
        public bool show_rain { get; set; }
        public int show_snow { get; set; }
        public string wind_unit { get; set; }
        public string pelm_measurement { get; set; }
        public int wx_cond_long_flag { get; set; }
        public int wx_cond_long_flag_night { get; set; }
        public bool use_new_precip_ranges_dataaccess { get; set; }
        public bool use_new_precip_ranges_static_data { get; set; }
        public object rf { get; set; }
        public object sf { get; set; }
        public string o { get; set; }
    }

    public class Fourteendays
    {
        public List<Period> periods { get; set; }
        public string historic_high { get; set; }
        public string historic_low { get; set; }
        public string time_period { get; set; }
        public string tempUnit { get; set; }
        public string wind_unit { get; set; }
        public bool wx_cond_long_flag { get; set; }
        public bool show_rain_flag { get; set; }
        public bool show_snow_flag { get; set; }
        public string o { get; set; }
    }

    public class Reports
    {
        public string placecode { get; set; }
        public bool aq_exists { get; set; }
        public string aq_index { get; set; }
        public string aq_level { get; set; }
        public bool uv_exists { get; set; }
        public string last_uv { get; set; }
        public string uv_index { get; set; }
        public string uv_label { get; set; }
        public bool pollen_exists { get; set; }
        public string pollen_index { get; set; }
        public string pollen_name { get; set; }
        public string pollen_adlevel { get; set; }
        public string flu_level { get; set; }
        public bool alternate { get; set; }
    }

    public class Swo
    {
        public string swo_level { get; set; }
        public string swo_type { get; set; }
    }

    public class Bug
    {
        public string bug_black_fly { get; set; }
        public string bug_mosquito { get; set; }
        public string bug_deer_fly { get; set; }
    }

    public class Night
    {
        public List<Period> periods { get; set; }
        public string night_name { get; set; }
        public int index { get; set; }
        public int id { get; set; }
    }

    public class HourlyData
    {
        public List<Night> nights { get; set; }
        public string o { get; set; }
        public List<object> days { get; set; }
    }

    public class Nightsky
    {
        public HourlyData hourly_data { get; set; }
    }

    public class Daysky
    {
        public HourlyData hourly_data { get; set; }
    }    
}
