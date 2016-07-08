using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEN;

namespace WindowsFormsApplication1
{
    class UserSingleton
    {
        private  User user;
        private static UserSingleton instance;

        private UserSingleton(){}

        public static UserSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSingleton();
                }
                return instance;
            }
        }


        public void setUser(User user)
        {
            this.user = user;
        }


        public User getUser()
        {
            return this.user;
        }




    }
}
