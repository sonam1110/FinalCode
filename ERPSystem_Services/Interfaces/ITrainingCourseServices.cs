using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface ITrainingCourseServices
    {
        void AddCourse(TrainingCourseModel course);
        void UpdateCourse(TrainingCourseModel course);
        void DeleteCourse(int courseId);
        void RestoreCourse(int courseId);

        List<TrainingCourseModel> GetCourses();
        TrainingCourseModel GetCourse(int courseId);
    }
}
