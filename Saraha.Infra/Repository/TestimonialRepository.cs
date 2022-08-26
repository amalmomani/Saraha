using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Saraha.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbcontext dbContext;

        public TestimonialRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
            Testimonial testimonialIsNull = GetTestimonialByUserId(testimonial.Userid);
            if (testimonialIsNull == null)
            {
                var p = new DynamicParameters();

                p.Add("@Contentt", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@Starss", testimonial.Stars, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@UserIdd", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.Connection.ExecuteAsync("Testimonial_Package.CreateTestimonial", p,
                    commandType: CommandType.StoredProcedure);

                return true;
            }
            else
            {
                testimonial.Testimonialid = testimonialIsNull.Testimonialid;
              return  UpdateTestimonial(testimonial);
            }
          

        }

        public bool DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();

            p.Add("@TestimonialIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("Testimonial_Package.DeleteTestimonial", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Testimonial> GetAllTestimonials()
        {
            IEnumerable<Testimonial> result = dbContext.Connection.Query<Testimonial>
                ("Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Testimonial GetTestimonialByUserId(int UserId)
        {
            var p = new DynamicParameters();

            p.Add("@UserIdd", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Testimonial> result = dbContext.Connection.Query<Testimonial>
                            ("Testimonial_Package.GetTestimonialByUserId",p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public List<UserTestemonial> GetUserTestemonial()
        {
            IEnumerable<UserTestemonial> result = dbContext.Connection.Query<UserTestemonial>
                ("DTOPackage.UserTestemonial", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool UpdateAcceptingStatus(int isAccepted, int testimonialId)
        {
            var p = new DynamicParameters();

            p.Add("@IsAcceptedd", isAccepted, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@TestimonialIdd", testimonialId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Testimonial_Package.UpdateAcceptingStatus", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();

            p.Add("@TestimonialIdd", testimonial.Testimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Contentt", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Starss", testimonial.Stars, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserIdd", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            bool status = UpdateAcceptingStatus(0,testimonial.Testimonialid);
            var result = dbContext.Connection.ExecuteAsync("Testimonial_Package.UpdateTestimonial", p,
                commandType: CommandType.StoredProcedure);

            return true;

        }
    }
}
