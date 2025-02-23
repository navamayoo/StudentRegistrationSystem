import React from "react";
//Icons
import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import BusinessIcon from '@mui/icons-material/Business';
import AutoStoriesIcon from '@mui/icons-material/AutoStories';
import SensorOccupiedIcon from '@mui/icons-material/SensorOccupied';
import MenuBookIcon from "@mui/icons-material/MenuBook";

//Components
import Student from "../pages/Student/Student";
import Classroom from "../pages/Class/Classroom";
import Subject from "../pages/Subject/Subject";
import Teacher from "../pages/Teacher/Teacher";
import AllocateSubject from "../pages/AllocateSubject/AllocateSubject";

//import CourseStudent from "../../pages/Admin/CourseStudents/CourseStudent";

export const routes = [
  {
    path: "/",
    component: <Student />,
    label: "Student",
    icon: <PeopleAltIcon />,
  },
  {
    path: "/teacher",
    component: <Teacher/>,
    label: "Teacher",
    icon: <SensorOccupiedIcon />,
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
  {
    path: "/allocate-subject",
    component: <AllocateSubject />,
    label: "Allocate-Subject",
    icon: <MenuBookIcon />,
  },
];