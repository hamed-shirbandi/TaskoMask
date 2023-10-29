namespace TaskoMask.BuildingBlocks.Contracts.Helpers;

public static class DomainConstValues
{
    public const int ORGANIZATION_NAME_MIN_LENGTH = 3;
    public const int ORGANIZATION_NAME_MAX_LENGTH = 50;
    public const int ORGANIZATION_DESCRIPTION_MIN_LENGTH = 3;
    public const int ORGANIZATION_DESCRIPTION_MAX_LENGTH = 100;
    public const int ORGANIZATION_MAX_PROJECTS_COUNT = 6;

    public const int PROJECT_NAME_MIN_LENGTH = 3;
    public const int PROJECT_NAME_MAX_LENGTH = 50;
    public const int PROJECT_DESCRIPTION_MIN_LENGTH = 3;
    public const int PROJECT_DESCRIPTION_MAX_LENGTH = 100;
    public const int PROJECT_MAX_BOARD_COUNT = 6;

    public const int BOARD_NAME_MIN_LENGTH = 3;
    public const int BOARD_NAME_MAX_LENGTH = 50;
    public const int BOARD_DESCRIPTION_MIN_LENGTH = 3;
    public const int BOARD_DESCRIPTION_MAX_LENGTH = 100;
    public const int BOARD_MAX_CARD_COUNT = 10;
    public const int BOARD_MAX_TASK_COUNT = 1000;
    public const int BOARD_MAX_MEMBER_COUNT = 10;

    public const int CARD_NAME_MIN_LENGTH = 3;
    public const int CARD_NAME_MAX_LENGTH = 50;
    public const int CARD_DESCRIPTION_MIN_LENGTH = 3;
    public const int CARD_DESCRIPTION_MAX_LENGTH = 100;

    public const int TASK_TITLE_MIN_LENGTH = 3;
    public const int TASK_TITLE_MAX_LENGTH = 50;
    public const int TASK_DESCRIPTION_MIN_LENGTH = 3;
    public const int TASK_DESCRIPTION_MAX_LENGTH = 2048;

    public const int OWNER_DISPLAYNAME_MIN_LENGTH = 3;
    public const int OWNER_DISPLAYNAME_MAX_LENGTH = 50;
    public const int OWNER_MAX_ORGANIZATIONS_COUNT = 6;

    public const int USER_PASSWORD_MIN_LENGTH = 4;
    public const int USER_PASSWORD_MAX_LENGTH = 50;

    public const int OWNER_EMAIL_MIN_LENGTH = 5;
    public const int OWNER_EMAIL_MAX_LENGTH = 50;

    public const int COMMENT_CONTENT_MAX_LENGTH = 512;
}
