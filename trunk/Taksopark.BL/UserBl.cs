using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;

namespace Taksopark.BL
{
    class UserBl : IUserBl
    {
        private const string ConnectionString = "conn";

        public void CreateRequest(DAL.Models.Request request)
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                uow.RequestRepository.Create(request);
            }
        }

        public void CreateComment(DAL.Models.Comment comment)
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                uow.CommentRepository.Create(comment);
            }
        }

        public void CreateUser(DAL.Models.User user)
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                uow.UserRepository.Create(user);
            }
        }

        public System.Collections.Generic.List<DAL.Models.Car> GetAllCars()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return uow.CarRepository.GetAllCars().ToList();
            }
        }
    }
}
