namespace FoodApp.Bal;

public class DAL_Helper
{
    public static String ConnStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("connectionString");

}