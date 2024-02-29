using MediatR;
using Staff.Application.Features.Staff.Queries.Dtos;
using Staff.Application.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Queries.GetFormData
{
    public class GetFormDataQuery:IRequest<ApiResponse<GetFormDataDto>>
    {
      
    }
}
