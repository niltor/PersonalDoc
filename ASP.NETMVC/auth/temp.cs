public class MicrosoftAccountOptions : OAuthOptions

    {
"https://assets.onestore.ms/cdnfiles/external/uhf/long/9a49a7e9d8e881327e81b9eb43dabc01de70a9bb/images/microsoft-gray.png"
        /// <summary>

        /// Initializes a new <see cref="MicrosoftAccountOptions"/>.

        /// </summary>

        public MicrosoftAccountOptions()

        {

            CallbackPath = new PathString("/signin-microsoft");

            AuthorizationEndpoint = MicrosoftAccountDefaults.AuthorizationEndpoint;

            TokenEndpoint = MicrosoftAccountDefaults.TokenEndpoint;

            UserInformationEndpoint = MicrosoftAccountDefaults.UserInformationEndpoint;

            Scope.Add("https://graph.microsoft.com/user.read");



            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");

            ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");

            ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");

            ClaimActions.MapJsonKey(ClaimTypes.Surname, "surname");

            ClaimActions.MapCustomJson(ClaimTypes.Email, user => user.Value<string>("mail") ?? user.Value<string>("userPrincipalName"));

        }

    }