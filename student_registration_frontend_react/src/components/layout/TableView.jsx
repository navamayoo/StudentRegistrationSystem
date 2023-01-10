import React from "react";

import Control from "../../components/controls/Control";
import {
  Paper,
  Table,
  TableContainer,
  TableHead,
  TableRow,
  TableBody,
  TableCell,
} from "@mui/material";

import { makeStyles } from "@mui/styles";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";

const useStyles = makeStyles({
  root: {
    "& .MuiTableCell-head": {
      color: "black",
      backgroundColor: "#2a9c3b",
    },
  },
});

export default function TableView(props) {
  const {
    headCells,
    tableData,
    setOpenPopup,
    setSelectedCode,
    setLoading,
    setOpen,
  } = props;

  const classes = useStyles();
  return (
    <>
      <TableContainer container={Paper}>
        <Table border="1" sx={{ borderColor: "primary.main" }}>
          <TableHead>
            <TableRow
              className={classes.root}
              sx={{ "& td": { padding: 0, textAlign: "center" } }}>
              {headCells.map((headCell) => (
                <>
                  <TableCell key={headCell.id}>{headCell.label}</TableCell>
                </>
              ))}
            </TableRow>
          </TableHead>

          <TableBody>
            {tableData.length > 0
              ? tableData.map((record) => (
                  <TableRow
                    key={record.id}
                    sx={{
                      "& td": { padding: 0, textAlign: "center" },
                      "&.MuiTableRow-root:hover": {
                        backgroundColor: "#c8e6c9",
                      },
                    }}>
                    <TableCell>{record.id}</TableCell>
                    <TableCell>{record.firstName}</TableCell>
                    <TableCell>{record.lastName}</TableCell>
                    <TableCell>{record.contactPerson}</TableCell>
                    <TableCell>{record.contactNo}</TableCell>
                    <TableCell>{record.email}</TableCell>
                    <TableCell>
                      {new Date(record.dateOfBirth).toISOString().split("T")[0]}{" "}
                    </TableCell>
                    <TableCell>{record.className}</TableCell>
                    <TableCell>
                      <Control.ActionButton
                        size="small"
                        color="primary"
                        onClick={() => {
                          setOpenPopup(true);
                          setSelectedCode(record.id);
                          setLoading(false);
                        }}>
                        <EditIcon fontSize="small" />
                      </Control.ActionButton>
                      <Control.ActionButton
                        size="small"
                        color="error"
                        onClick={() => {
                          setOpen(true);
                          setSelectedCode(record.id);
                        }}>
                        <DeleteIcon fontSize="small" />
                      </Control.ActionButton>
                    </TableCell>
                  </TableRow>
                ))
              : "Loading"}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
}
