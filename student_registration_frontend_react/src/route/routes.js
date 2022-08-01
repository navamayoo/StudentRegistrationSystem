import React from "react";
//Icons
import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import BusinessIcon from '@mui/icons-material/Business';
import AutoStoriesIcon from '@mui/icons-material/AutoStories';
//import MenuBookIcon from "@mui/icons-material/MenuBook";

//Components
import Student from "../pages/Student/Student";
import Classroom from "../pages/Classroom/Classroom";
import Subject from "../pages/Subject/Subject";

//import CourseStudent from "../../pages/Admin/CourseStudents/CourseStudent";

export const routes = [
  {
    path: "/",
    component: <Student />,
    label: "Student",
    icon: <PeopleAltIcon />,
  },
  {
    path: "/subject",
    component: <Subject/>,
    label: "Subject",
    icon: <AutoStoriesIcon />,
  },
  {
    path: "/classroom",
    component: <Classroom/>,
    label: "Classroom",
    icon: <BusinessIcon />,
  },
//   {
//     path: "/course-student",
//     component: <CourseStudent />,
//     label: "Course-Student",
//     icon: <MenuBookIcon />,
//   },
];