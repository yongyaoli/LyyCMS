namespace LyyCMS
{
    public class LyyCMSConsts
    {
        public const string LocalizationSourceName = "LyyCMS";

        public const string ConnectionStringName = "Default";

        // 多租户设置
        public const bool MultiTenancyEnabled = false;

        //MySql 最大ID长度
        public const int MaxIdLen = 300;


        //默认每页条数
        public const int DefaultPageSize = 10;

        public const int MaxPageSize = 1000;
    }

    /// <summary>
    /// 实体长度单位
    /// </summary>
    public static class EntityLengthNames
    {
        public const int Length8 = 8;
        public const int Length16 = 16;
        public const int Length32 = 32;
        public const int Length64 = 65;
        public const int Length128 = 128;
        public const int Length256 = 256;
        public const int Length512 = 512;

        public const int Length1024 = 1024;

    }
}
