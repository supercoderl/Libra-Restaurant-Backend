using System.Net.NetworkInformation;

namespace LibraRestaurant.Domain.Errors;

public static class DomainErrorCodes
{
    public static class User
    {
        // User Validation
        public const string EmptyId = "USER_EMPTY_ID";
        public const string EmptyFirstName = "USER_EMPTY_FIRST_NAME";
        public const string EmptyLastName = "USER_EMPTY_LAST_NAME";
        public const string EmptyMobile = "USER_EMPTY_MOBILE";
        public const string EmailExceedsMaxLength = "USER_EMAIL_EXCEEDS_MAX_LENGTH";
        public const string FirstNameExceedsMaxLength = "USER_FIRST_NAME_EXCEEDS_MAX_LENGTH";
        public const string LastNameExceedsMaxLength = "USER_LAST_NAME_EXCEEDS_MAX_LENGTH";
        public const string MobileExceedsMaxLength = "USER_MOBILE_EXCEEDS_MAX_LENGTH";
        public const string InvalidEmail = "USER_INVALID_EMAIL";

        // User Password Validation
        public const string EmptyPassword = "USER_PASSWORD_MAY_NOT_BE_EMPTY";
        public const string ShortPassword = "USER_PASSWORD_MAY_NOT_BE_SHORTER_THAN_6_CHARACTERS";
        public const string LongPassword = "USER_PASSWORD_MAY_NOT_BE_LONGER_THAN_50_CHARACTERS";
        public const string UppercaseLetterPassword = "USER_PASSWORD_MUST_CONTAIN_A_UPPERCASE_LETTER";
        public const string LowercaseLetterPassword = "USER_PASSWORD_MUST_CONTAIN_A_LOWERCASE_LETTER";
        public const string NumberPassword = "USER_PASSWORD_MUST_CONTAIN_A_NUMBER";
        public const string SpecialCharPassword = "USER_PASSWORD_MUST_CONTAIN_A_SPECIAL_CHARACTER";

        // General
        public const string AlreadyExists = "USER_ALREADY_EXISTS";
        public const string PasswordIncorrect = "USER_PASSWORD_INCORRECT";
    }

    public static class MenuItem
    {
        // Item Validation
        public const string EmptyId = "ITEM_EMPTY_ID";
        public const string EmptyTitle = "ITEM_EMPTY_TITLE";
        public const string EmptySlug = "ITEM_EMPTY_SLUG";
        public const string EmptySKU = "ITEM_EMPTY_SKU";
        public const string EmptyPrice = "ITEM_EMPTY_PRICE";
        public const string EmptyQuantity = "ITEM_EMPTY_QUANTITY";
        public const string TitleExceedsMaxLength = "ITEM_TITLE_EXCEEDS_MAX_LENGTH";
        public const string SlugExceedsMaxLength = "ITEM_SLUG_EXCEEDS_MAX_LENGTH";
        public const string SKUExceedsMaxLength = "ITEM_SKU_EXCEEDS_MAX_LENGTH";

        // General
        public const string AlreadyExists = "ITEM_ALREADY_EXISTS";
    }

    public static class Menu
    {
        // Menu Validation
        public const string EmptyId = "MENU_EMPTY_ID";
        public const string EmptyName = "MENU_EMPTY_TITLE";
        public const string EmptyStrore = "MENU_EMPTY_STORE";

        // General
        public const string AlreadyExists = "MENU_ALREADY_EXISTS";
    }

    public static class Category
    {
        // Menu Validation
        public const string EmptyId = "CATEGORY_EMPTY_ID";
        public const string EmptyName = "CATEGORY_EMPTY_TITLE";

        // General
        public const string AlreadyExists = "CATEGORY_ALREADY_EXISTS";
    }

    public static class Currency
    {
        // Menu Validation
        public const string EmptyId = "CURRENCY_EMPTY_ID";
        public const string EmptyName = "CURRENCY_EMPTY_TITLE";

        // General
        public const string AlreadyExists = "CURRENCY_ALREADY_EXISTS";
    }

    public static class Order
    {
        // Order Validation
        public const string EmptyId = "ORDER_EMPTY_ID";
        public const string EmptyOrderNo = "ORDER_EMPTY_ORDER_NO";
        public const string EmptyStore = "ORDER_EMPTY_STORE_ID";
        public const string EmptyServant = "ORDER_EMPTY_SERVANT_ID";
        public const string EmptyCashier = "ORDER_EMPTY_CASHIER_ID";
        public const string EmptyReservation = "ORDER_EMPTY_RESERVATION_ID";
        public const string EmptyPriceCalculated = "ORDER_EMPTY_PRICE_CALCULATED";
        public const string EmptySubtotal = "ORDER_EMPTY_SUBTOTAL";
        public const string EmptyTax = "ORDER_EMPTY_TAX";
        public const string EmptyTotal = "ORDER_EMPTY_TOTAL";

        // General
        public const string AlreadyExists = "ORDER_ALREADY_EXISTS";
    }

    public static class Store
    {
        // Store Validation
        public const string EmptyId = "STORE_EMPTY_ID";
        public const string EmptyName = "STORE_EMPTY_NAME";
        public const string EmptyCity = "STORE_EMPTY_CITY_ID";
        public const string EmptyDistrict = "STORE_EMPTY_DISTRICT_ID";
        public const string EmptyWard = "STORE_EMPTY_WARD_ID";
        public const string EmptyAddress = "STORE_EMPTY_ADDRESS";

        // General
        public const string AlreadyExists = "STORE_ALREADY_EXISTS";
    }

    public static class Reservation
    {
        // Reservation Validation
        public const string EmptyId = "RESERVATION_EMPTY_ID";
        public const string EmptyTableNumber = "RESERVATION_EMPTY_TABLE_NUMBER";
        public const string EmptyCapacity = "RESERVATION_EMPTY_CAPACITY";
        public const string EmptyStore = "RESERVATION_EMPTY_STORE_ID";

        // General
        public const string AlreadyExists = "RESERVATION_ALREADY_EXISTS";
    }

    public static class OrderLine
    {
        // Order Line Validation
        public const string EmptyId = "ORDERLINE_EMPTY_ID";
        public const string EmptyOrder = "ORDERLINE_EMPTY_ORDER_ID";
        public const string EmptyItem = "ORDERLINE_EMPTY_ITEM_ID";
        public const string EmptyQuantity = "ORDERLINE_EMPTY_QUANTITY";

        // General
        public const string AlreadyExists = "ORDERLINE_ALREADY_EXISTS";
    }
}