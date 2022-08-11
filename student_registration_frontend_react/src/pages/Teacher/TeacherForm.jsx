import React, { useState, useEffect } from "react";
import { Formik, Form } from "formik";
import Control from "../../components/controls/Control";
import * as Yup from "yup";
import { Grid, Box} from "@mui/material";
import TeacherService from "../../service/TeacherService";

export default function TeacherForm({
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
    contactNo:"",
    email: "",
    roomId: "",
  };

  const [form, setForm] = useState(initialValues);


  const validationSchema = Yup.object({
    firstName: Yup.string().required("Required"),
    lastName: Yup.string().required("Required"),
    email: Yup.string().email("Invalid Email Format").required("Required!"),

  });

  const handelSubmit = async (values) => {
    console.log("its works");
    try {
      if (validationSchema) {
        if (id) {
          await TeacherService.update(id, values).then(
            (response) => {
              console.log("update");
              setPopupClose(false);
              setCode();
            }
          );
        } else {
          await TeacherService.create(values).then((response) => {
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



  const getTeacherByCode = async (id) => {
    await TeacherService.getByCode(id)
      .then((response) => {
        setForm(response);
        setLoading(true);
      })
      .catch((e) => {
        console.log(e);
      });
  };



  useEffect(() => {
    if (id != null) {
      getTeacherByCode(id);
    } else {
      setLoading(true);
    }
  }, [id]);


  return (
    <>
      {loading ? (
        <Formik
          initialValues={form}
          validationSchema={validationSchema}
          onSubmit={async (values, onSubmitProps) => {
            await handelSubmit(values);
            onSubmitProps.resetForm();
          }}
        >
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
                  <Grid item xs={6}>
                    <Control.Input name="contactNo" label="Contact No" />
                  </Grid>
                  <Grid item xs={12}>
                    <Control.Input name="email" label="Email" />
                  </Grid>





                 
                </Grid>
                <Grid>
                    <Control.Button
                      type="submit"
                      text="Submit"
                      color="success"
                    />
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
