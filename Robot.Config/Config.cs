namespace Robot.Config
{
    public static class Config
    {
        public static string FilePath { get; set; }

        static Config()
        {
            FilePath = "Config/Config.xml";
        }
 
  
    }
}
