using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace LashaRestaurant.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap< LashaRestaurant.DataAccess.Models.Employee, LashaRestaurant.Models.Employee.Get.Employee>(MemberList.Source);
            CreateMap<LashaRestaurant.DataAccess.Models.EmployeeBankAccount, LashaRestaurant.Models.Employee.Get.EmployeeBankAccount>(MemberList.Source);
            CreateMap<LashaRestaurant.DataAccess.Models.EmployeeSalary, LashaRestaurant.Models.Employee.Get.EmployeeSalary>(MemberList.Source);

            CreateMap< LashaRestaurant.Models.Employee.Post.EmployeePost, LashaRestaurant.DataAccess.Models.Employee>(MemberList.Source);
            CreateMap<LashaRestaurant.Models.Employee.Put.EmployeePut, LashaRestaurant.DataAccess.Models.Employee>(MemberList.Source);

        }

    }
}
