import React,{useState,useEffect} from "react";
import PageHeader from "../../components/layout/PageHeader";
import ClassroomForm from "./ClassroomForm";
import BusinessIcon from '@mui/icons-material/Business';
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import AddIcon from "@mui/icons-material/Add";
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Toolbar } from "@mui/material";
import Control from "../../components/controls/Control";
import Popup from "../../components/controls/Dialog/Popup";
import { makeStyles } from "@mui/styles";
import ClassroomService from "../../service/ClassroomService";
import DialogBox from "../../components/controls/Dialog/DialogBox";
const useStyles = makeStyles({
  root: {
    "& .MuiTableCell-head": {
      color: "black",
      backgroundColor: "#2a9c3b",
    },
  },
});

export default function Classroom() {
  const classes = useStyles();
  const [records, setRecords] = useState({});
  const [openPopup, setOpenPopup] = useState(false);
  const [FormSubmitted, setFormSubmitted] = useState(0);
  const [loading, setLoading] = useState(false);
  const [selectedCode, setSelectedCode] = useState(null);
    const [open, setOpen] = useState(false);



  const getClasses = async () => {
    await ClassroomService.getAll()
      .then((response) => {
        setRecords(response);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const deleteNote = async () => {
   
    await ClassroomService.delete(selectedCode)
      .then((response) => {
        setSelectedCode(null)
        setOpen(false)
        setFormSubmitted((prev) => prev + 1);
        console.log(response);
        
      })
      .catch((e) => {
        console.log(e);
      });

};

  useEffect(() => {
    getClasses();
  }, [FormSubmitted]);

  const handelSetOpenPopup = (val) => {
    setOpenPopup(val);
  };

  return(
    <>
  
  <PageHeader
        title="Class Room"
        icon={<BusinessIcon fontSize="large" />}
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
        <TableContainer container={Paper} >
          <Table border="1">
            <TableHead>
              <TableRow className={classes.root}>
                {/* <TableCell>Id</TableCell> */}
                <TableCell>Class Name</TableCell>
                <TableCell>Action</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
            {records&&
            records.length > 0
                ? records.map((record) => (
                    <TableRow key={record.id} sx={{ "& td": { padding: 0 },"&.MuiTableRow-root:hover":{backgroundColor: '#c8e6c9' } }}>
                      {/* <TableCell>{record.id}</TableCell> */}
                      <TableCell>{record.name}</TableCell>
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

                        <Control.ActionButton size="small" color="error"
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
        title="Class Form"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        {openPopup && (
          <ClassroomForm
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
