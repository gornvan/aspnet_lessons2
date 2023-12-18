using Microsoft.AspNetCore.Mvc.Filters;

namespace SOLID.Filters
{
    public class ForbiddenDayOfWeekFilterAtribute : ActionFilterAttribute
    {
        private DayOfWeek _dayOfWeek;
        public ForbiddenDayOfWeekFilterAtribute(DayOfWeek dayOfWeek) {
            _dayOfWeek = dayOfWeek;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (DateTime.Now.DayOfWeek == _dayOfWeek)
            {
                throw new FileNotFoundException();
            }

            base.OnActionExecuting(context);
        }
    }
}
