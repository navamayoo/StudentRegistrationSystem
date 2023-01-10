import React, { useState, useEffect } from "react";
import PageHeader from "../../components/layout/PageHeader";
import PersonAddAlt1Icon from "@mui/icons-material/PersonAddAlt1";
import AddIcon from "@mui/icons-material/Add";
import StudentForm from "./StudentForm";
import Popup from "../../components/controls/Dialog/Popup";
import Control from "../../components/controls/Control";
import { Paper, Toolbar } from "@mui/material";
import StudentService from "../../service/StudentService";
//import { makeStyles } from "@mui/styles";
import DialogBox from "../../components/controls/Dialog/DialogBox";
import TableView from "../../components/layout/TableView";

// const useStyles = makeStyles({
//   root: {
//     "& .MuiTableCell-head": {
//       color: "black",
//       backgroundColor: "#2a9c3b",
//     },
//   },
// });

export default function Student() {
  //const classes = useStyles();
  const [records, setRecords] = useState({});
  const [openPopup, setOpenPopup] = useState(false);
  const [FormSubmitted, setFormSubmitted] = useState(0);
  // const [data, setData] = useState({});
  const [loading, setLoading] = useState(false);
  const [selectedCode, setSelectedCode] = useState(null);
  const [open, setOpen] = useState(false);

  const getStudents = async () => {
    await StudentService.getAll()
      .then((response) => {
        setRecords(response);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const deleteNote = async () => {
    await StudentService.delete(selectedCode)
      .then((response) => {
        setSelectedCode(null);
        setOpen(false);
        setFormSubmitted((prev) => prev + 1);
        console.log(response);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const handelSetOpenPopup = (val) => {
    setOpenPopup(val);
  };

  useEffect(() => {
    getStudents();
  }, [FormSubmitted]);

  const headCells = [
    {
      id: (row) => row["id"],
      name: "id",
      label: "Student Id",
    },
    {
      id: (row) => row["firstName"],
      name: "firstName",
      label: "First Name",
    },
    {
      id: (row) => row["lastName"],
      name: "lastName",
      label: "Last Name",
    },
    {
      id: (row) => row["contactPerson"],
      name: "contactPerson",
      label: "Contact Person",
    },
    {
      id: (row) => row["contactNo"],
      name: "contactNo",
      label: "Contact No",
    },
    {
      id: (row) => row["email"],
      name: "email",
      label: "Email",
    },
    {
      id: (row) => row[new Date("dateOfBirth").toISOString().split("T")[0]],
      name: "dateOfBirth",
      label: "DateOfBirth",
    },
    {
      id: (row) => row["className"],
      name: "className",
      label: "DateOfBirth",
    },
    {
      id: (row) => row["action"],
      name: "action",
      label: "Action",
    },
  ];

  return (
    <>
      <PageHeader
        title="Student"
        icon={<PersonAddAlt1Icon fontSize="large" />}
      />

      <Paper
        elevation={0}
        variant="outlined"
        style={{ margin: "16px 0px", padding: 10 }}>
        <Toolbar>
          <Control.Button
            text="Add New"
            variant="outlined"
            onClick={() => {
              setOpenPopup(true);
            }}
            startIcon={<AddIcon />}
          />
        </Toolbar>
        <TableView
          headCells={headCells}
          tableData={records}
          setOpenPopup={setOpenPopup}
          setSelectedCode={setSelectedCode}
          setLoading={setLoading}
          setOpen={setOpen}
        />
      </Paper>
      <Popup
        title="Student Form"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}>
        {openPopup && (
          <StudentForm
            id={selectedCode}
            setCode={() => setSelectedCode(null)}
            loading={loading}
            setLoading={(val) => setLoading(val)}
            setFormSubmitted={setFormSubmitted}
            setPopupClose={handelSetOpenPopup}
          />
        )}
      </Popup>
      <DialogBox
        title="Warning Record will be Delete"
        open={open}
        setOpen={setOpen}
        deleteNote={deleteNote}
      />
    </>
  );
}
