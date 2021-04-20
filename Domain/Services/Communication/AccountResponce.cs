using Api.Domain.Models.Account;
namespace Api.Domain.Services.Communication
{
    public partial class UserResponce:BaseResponce
    {
        public User User { get;private set; }
        public UserRoles UserRoles { get;private set; }
        private UserResponce(bool success,string message,User user):base(success,message){
            User=user;
        }

        public UserResponce(User user):this(true,string.Empty,user){}

     
        public UserResponce(string message):this(false,message,null)
        {
            
        }
    
    }

    public partial class UserRolesResponce:BaseResponce
    {
        
        public UserRoles UserRoles { get;private set; }
        private UserRolesResponce(bool success,string message,UserRoles userRoles):base(success,message){
            UserRoles=userRoles;
        }

        public UserRolesResponce(UserRoles userRoles):this(true,string.Empty,userRoles){}

     
        public UserRolesResponce(string message):this(false,message,null)
        {
            
        }
    }
    
}