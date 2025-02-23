import React, { useState, useEffect } from "react";
import { Formik, Form } from "formik";
import Control from "../../components/controls/Control";
import * as Yup from "yup";
import { Grid, Box, TextField } from "@mui/material";
import StudentService from "../../service/StudentService";
import ClassroomService from "../../service/ClassroomService";
//import { Grid, Box, Stack, TextField } from "@mui/material";
// import { AdapterDateFns } from "@mui/lab/AdapterDateFns";
// import AdapterDateFns from "@mui/lab/modern/AdapterDateFns";
// import { LocalizationProvider, DatePicker } from "@mui/lab";
import { DateTimePicker } from "@mui/x-date-pickers/DateTimePicker";

import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
//import { StaticDatePicker } from '@mui/x-date-pickers/StaticDatePicker';

export default function StudentForm({
  id,
  loading,
  setLoading,
  setFormSubmitted,
  setCode,
  setPopupClose,
}) {
  const initialValues = {
    firstName: "",
    lastName: "",
    contactPerson: "",
    contactNo: "",
    email: "",
    dateOfBirth: "",
    age: 0,
    ClassId: "",
  };

  const [form, setForm] = useState(initialValues);
  const [classrooms, setClassrooms] = useState([]);
  const [selectDate, setSelectDate] = useState(null);
  const [age, setAge] = useState(null);

  const validationSchema = Yup.object({
    firstName: Yup.string().required("Required"),
    lastName: Yup.string().required("Required"),
    email: Yup.string().email("Invalid Email Format").required("Required!"),
    dateOfBirth: Yup.string().required("Required"),
    ClassId: Yup.string().required("Required"),
    contactNo: Yup.number().min(9, "Must be more than 10 characters"),
  });

  const handelSubmit = async (values) => {
    console.log("its works");
    try {
      if (validationSchema) {
        if (id) {
          await StudentService.update(id, values).then((response) => {
            console.log("update");
            setPopupClose(false);
            setCode();
          });
        } else {
          await StudentService.create(values).then((response) => {
            console.log("crete");
            setPopupClose(false);
          });
        }
      }
      setFormSubmitted((prev) => prev + 1);
    } catch (e) {
      alert(e);
    }
  };

  // console.log(selectDate);
  // console.log("selectDate", new Date(selectDate).toISOString());
  // console.log("select-Date", selectDate);
  // console.log("selectDate_", initialValues.dateOfBirth);

  // const _newDate = new Date(selectDate).getFullYear();

  // console.log("_newDate", _newDate);

  //console.log('values',form.values);

  const handleDateChange = () => {
    const _selectDate = new Date(selectDate).getFullYear();
    const _today = new Date().getFullYear();
    const _age = _today - _selectDate;
    setAge(_age);
  };

  const getStudentByCode = async (id) => {
    await StudentService.getByCode(id)
      .then((response) => {
        const dateOfBirth = new Date(response.dateOfBirth)
          .toISOString()
          .split("T")[0];
        response = JSON.parse(
          JSON.stringify(response).replace(/:null/gi, ':""')
        );
        console.log(response);
 console.log(response.class);
        setClassrooms(response.class);

        setAge(response.age);
        setSelectDate(dateOfBirth);
                console.log("classrooms", classrooms);
        setForm({ ...response, dateOfBirth: dateOfBirth });

        setLoading(true);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const getClassroom = async () => {
    await ClassroomService.getAll()
      .then((response) => {
        setClassrooms(response);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  useEffect(() => {
    getClassroom();
    if (id != null) {
      getStudentByCode(id);
    } else {
      setLoading(true);
    }
  }, [id]);

  console.log(form);

  const today = new Date().toISOString().split("T")[0];
  return (
    <>
      {loading ? (
        <Formik
          initialValues={form}
          validationSchema={validationSchema}
          onSubmit={async (values, onSubmitProps) => {
            const dateOfBirth = new Date(selectDate)
              .toISOString()
              .split("T")[0];
            const data = { ...values, dateOfBirth, age };
            await handelSubmit(data);

            onSubmitProps.resetForm();
          }}>
          {() => (
            <Form>
              <Box sx={{ flexGrow: 1 }} spacing={2}>
                <Grid container spacing={2}>
                  <Grid item xs={6}>
                    <Control.Input name="firstName" label="First Name" />
                  </Grid>
                  <Grid item xs={6}>
                    <Control.Input name="lastName" label="Last Name" />
                  </Grid>
                  <Grid item xs={12}>
                    <Control.Input name="email" label="Email" />
                  </Grid>
                  <Grid item xs={6}>
                    <Control.Input
                      name="contactPerson"
                      label="Contact Person"
                    />
                  </Grid>
                  <Grid item xs={6}>
                    <Control.Input name="contactNo" label="Contact No" />
                  </Grid>

                  <Grid item xs={6}>
                    <Control.Input
                      type="date"
                      label="Date Of Birth"
                      name="dateOfBirth"
                      InputLabelProps={{
                        shrink: true,
                      }}
                      inputProps={{
                        max: today,
                      }}
                    />
                  </Grid>
                  <Grid item xs={6}>
                    <h5>Age: {age}</h5>
                  </Grid>

                  <Grid item xs={6}>
                    <Control.SelectInput
                      label="Classroom"
                      options={classrooms}
                      name="ClassId"
                    />
                  </Grid>
                </Grid>
                <Grid>
                  <Control.Button type="submit" text="Submit" color="success" />
                  <Control.Button type="reset" text="Reset" />
                </Grid>
              </Box>
            </Form>
          )}
        </Formik>
      ) : (
        "Loading"
      )}
    </>
  );
}
