﻿using Ardalis.Specification;

namespace GatePass.Core.PassAggregate.Specifications
{
    public class SinglePassWithVisitorAndLocationPaginationSpec : Specification<SinglePass>
    {
        public SinglePassWithVisitorAndLocationPaginationSpec(int pageIndex, int pageSize, string searchString, bool exitPending = false)
        {
            if (exitPending)
            {
                Query
                .Include(p => p.Visitor)
                .Include(p => p.Location)
                .Where(p =>
                    (p.Department.ToLower().Contains(searchString.ToLower()) ||
                    p.Visitor!.FirstName.ToLower().Contains(searchString.ToLower()) ||
                    p.Visitor!.LastName.ToLower().Contains(searchString.ToLower()) ||
                    p.Visitor!.Phone.ToLower().Contains(searchString.ToLower()))
                    && p.OutTime.Equals(TimeSpan.Zero)
                    && p.VisitDate.Date.Equals(DateTime.Today)
                 )
                .OrderByDescending(p => p.VisitDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
            }
            else
            {
                Query
                .Include(p => p.Visitor)
                .Include(p => p.Location)
                .Where(p =>
                    p.Department.ToLower().Contains(searchString.ToLower()) ||
                    p.Visitor!.FirstName.ToLower().Contains(searchString.ToLower()) ||
                    p.Visitor!.LastName.ToLower().Contains(searchString.ToLower()) ||
                    p.Visitor!.Phone.ToLower().Contains(searchString.ToLower())
                 )
                .OrderByDescending(p => p.VisitDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
            }

            
        }
    }
}
