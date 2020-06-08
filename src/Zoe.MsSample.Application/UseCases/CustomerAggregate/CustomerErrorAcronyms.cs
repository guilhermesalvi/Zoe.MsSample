namespace Zoe.MsSample.Application.UseCases.CustomerAggregate
{
    public class CustomerErrorAcronyms
    {
        // Id
        public static string CUSTOMER_INVALID_ID_FORMAT = "CUSTOMER_INVALID_ID_FORMAT";
        public static string CUSTOMER_ID_NOT_EXISTS = "CUSTOMER_ID_NOT_EXISTS";

        // FullName
        public static string CUSTOMER_INVALID_EMPTY_FULLNAME = "CUSTOMER_INVALID_EMPTY_FULLNAME";
        public static string CUSTOMER_INVALID_FULLNAME_LENGHT = "CUSTOMER_INVALID_FULLNAME_LENGHT";

        // Alias
        public static string CUSTOMER_INVALID_EMPTY_ALIAS = "CUSTOMER_INVALID_EMPTY_ALIAS";
        public static string CUSTOMER_INVALID_ALIAS_LENGHT = "CUSTOMER_INVALID_ALIAS_LENGHT";

        // Email
        public static string CUSTOMER_INVALID_EMPTY_EMAIL = "CUSTOMER_INVALID_EMPTY_EMAIL";
        public static string CUSTOMER_INVALID_EMAIL_FORMAT = "CUSTOMER_INVALID_EMAIL_FORMAT";
        public static string CUSTOMER_INVALID_EMAIL_LENGHT = "CUSTOMER_INVALID_EMAIL_LENGHT";

        // BirthDate
        public static string CUSTOMER_INVALID_BIRTHDATE_FORMAT = "CUSTOMER_INVALID_BIRTHDATE_FORMAT";
        public static string CUSTOMER_INVALID_OLDER_BIRTHDATE = "CUSTOMER_INVALID_OLDER_BIRTHDATE";

        // CommandHandler
        public static string CUSTOMER_EMAIL_ALREADY_EXISTS = "CUSTOMER_EMAIL_ALREADY_EXISTS";
        public static string CUSTOMER_FAILURE_DURING_DATA_PROCESSING = "CUSTOMER_FAILURE_DURING_DATA_PROCESSING";
        public static string CUSTOMER_NON_EXISTENT = "CUSTOMER_NON_EXISTENT";
    }
}
