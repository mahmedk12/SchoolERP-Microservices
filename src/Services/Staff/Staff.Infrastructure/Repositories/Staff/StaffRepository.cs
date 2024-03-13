using Microsoft.EntityFrameworkCore;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Domain.Entities.Staff;
using Staff.Infrastructure.Persistence;
using Staff.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Repositories.Staff
{
    public class StaffRepository : RepositoryBase<StaffPersonalInfo>, IStaffRepository
    {
        private readonly StaffDbContext _dbContext;
        public StaffRepository(StaffDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StaffPersonalInfo> GetStaffInfoById(int id, bool includeAll = true)
        {
            IQueryable<StaffPersonalInfo> query =  _dbContext.Set<StaffPersonalInfo>();
            query = query
                    .Where(x => x.Id == id);
            if (includeAll)
            {
                query = query
                    .Include(x => x.EmploymentDetail)
                    .Include(x => x.EmploymentDetail.PositionLevel)
                    .Include(x => x.EmploymentDetail.Type)
                    .Include(x => x.EmploymentDetail.Status)
                    .Include(x=>x.EmploymentDetail.DepartmentCategory)
                    .Include(x=>x.EmploymentDetail.DepartmentInfos)
                        .ThenInclude(y=>y.DepartmentInfo)
                    .Include(x => x.EducationDetails)
                        .ThenInclude(y => y.DegreeLevel)
                     .AsQueryable();
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
