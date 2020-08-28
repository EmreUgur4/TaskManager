namespace TaskManager.Entities.Messages
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExists = 101,
        EmailAlreadyExists = 102,
        UserIsNotActive = 151,
        UserNameOrPassWrong = 152,
        CheckYourEmail = 153,
        UserAlreadyActive = 154,
        ActivateIdDoesNotExist = 155,
        UserNotFound = 156,
        ProfileCouldNotUpdated = 157,
        UserCouldNotFind = 158,
        UserCouldNotDelete = 159,
        Exception = 160
    }
}
