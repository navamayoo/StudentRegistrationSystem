import React, { useState, useEffect } from "react";
import PageHeader from "../../components/layout/PageHeader";
import PersonAddAlt1Icon from "@mui/icons-material/PersonAddAlt1";
import AddIcon from "@mui/icons-material/Add";
import TeacherForm from "./TeacherForm";
import Popup from "../../components/controls/Dialog/Popup";
import Control from "../../components/controls/Control";
import {
  Paper,
  Table,
  TableContainer,
  TableHead,
  TableRow,
  TableBody,
  TableCell,
  Toolbar,
} from "@mui/material";
import TeacherService from "../../service/TeacherService";
import { makeStyles } from "@mui/styles";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import DialogBox from "../../components/controls/Dialog/DialogBox";

const useStyles = makeStyles({
  root: {
    "& .MuiTableCell-head": {
      color: "black",
      backgroundColor: "#2a9c3b",
    },
  },
});

export default function Teacher() {
  const classes = useStyles();
  const [records, setRecords] = useState({});
  const [openPopup, setOpenPopup] = useState(false);
  const [FormSubmitted, setFormSubmitted] = useState(0);
  // const [data, setData] = useState({});
  const [loading, setLoading] = useState(false);
  const [selectedCode, setSelectedCode] = useState(null);
  const [open, setOpen] = useState(false);

  const getTeachers = async () => {
    await TeacherService.getAll()
      .then((response) => {
        setRecords(response);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const deleteNote = async () => {
    await TeacherService.delete(selectedCode)
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
    getTeachers();
  }, [FormSubmitted]);

  return (
    <>
      <PageHeader
        title="Teacher"
        icon={<PersonAddAlt1Icon fontSize="large" />}
      />

      <Paper
        elevation={0}
        variant="outlined"
        style={{ margin: "16px 0px", padding: 10 }}
      >
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
        <TableContainer container={Paper}>
          <Table border="1" sx={{ borderColor: "primary.main" }}>
            <TableHead>
              <TableRow
                className={classes.root}
                sx={{ "& td": { padding: 0, textAlign: "center" } }}
              >
                <TableCell>Code</TableCell>
                <TableCell>First Name</TableCell>
                <TableCell>Last Name</TableCell>
                <TableCell>Contact Person</TableCell>
                <TableCell>Contact No</TableCell>
                <TableCell>E-mail</TableCell>
                <TableCell>Date Of Birth</TableCell>
                <TableCell>Class Room</TableCell>
                <TableCell>Action</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {records.length > 0
                ? records.map((record) => (
                    <TableRow
                      key={record.id}
                      sx={{
                        "& td": { padding: 0, textAlign: "center" },
                        "&.MuiTableRow-root:hover": {
                          backgroundColor: "#c8e6c9",
                        },
                      }}
                    >
                      <TableCell>{record.id}</TableCell>
                      <TableCell>{record.firstName}</TableCell>
                      <TableCell>{record.lastName}</TableCell>
                      <TableCell>{record.email}</TableCell>
                      <TableCell>
                        {
                          new Date(record.dateOfBirth)
                            .toISOString()
                            .split("T")[0]
                        }{" "}
                      </TableCell>
                      <TableCell>{record.departmentName}</TableCell>
                      <TableCell>
                        <Control.ActionButton
                          size="small"
                          color="primary"
                          onClick={() => {
                            setOpenPopup(true);
                            setSelectedCode(record.id);
                            setLoading(false);
                          }}
                        >
                          <EditIcon fontSize="small" />
                        </Control.ActionButton>
                        <Control.ActionButton
                          size="small"
                          color="error"
                          onClick={() => {
                            setOpen(true);
                            setSelectedCode(record.id);
                          }}
                        >
                          <DeleteIcon fontSize="small" />
                        </Control.ActionButton>
                      </TableCell>
                    </TableRow>
                  ))
                : "Loading"}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
      <Popup
        title="Teacher Form"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        {openPopup && (
          <TeacherForm
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
