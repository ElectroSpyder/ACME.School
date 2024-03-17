﻿using ACME.School.Core.Models;
using ACME.School.Core.Persistences;
using AutoMapper;
using MediatR;

namespace ACME.School.Core.Features.Students.Queries.GetStudentWithCourses
{
    public class GetStudentWithCourseQueryHandler : IRequestHandler<GetStudentWithCourseQuery, List<StudentWithCoursesVm>>
    {
        private readonly IContractRespository _contractRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetStudentWithCourseQueryHandler(IContractRespository contractRespository, IStudentRepository studentRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _contractRepository = contractRespository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentWithCoursesVm>> Handle(GetStudentWithCourseQuery request, CancellationToken cancellationToken)
        {
            var contracts = await _contractRepository.GetAllContractsInRangeDate(request.StartDate, request.EndDate);

            var listStudent = new List<StudentWithCoursesVm>();

            if(contracts == null) return listStudent;

            foreach (var contract in contracts)
            {
                if(listStudent.Count > 0)
                {
                    foreach (var studentModel in listStudent)
                    {
                        if(studentModel.Student.StudentId == contract.StudentId)
                        {
                            studentModel.Courses.Add(
                                _mapper.Map<CourseModel>(
                                    await _courseRepository.GetByIdAsync(contract.CourseId)));
                        }
                    }
                }
                else
                {               
                    listStudent.Add(new StudentWithCoursesVm
                    {
                        Student = _mapper.Map<StudentModel>(
                            await _studentRepository.GetByIdAsync(
                                contract.StudentId)),
                        Courses = _mapper.Map<List<CourseModel>>(
                            await _courseRepository.GetByIdAsync(contract.CourseId))
                    });
                }
                
            }
            return listStudent;
        }
    }
}
