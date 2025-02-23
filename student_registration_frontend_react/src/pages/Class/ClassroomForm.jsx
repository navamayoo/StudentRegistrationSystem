import React, { useState, useEffect } from "react";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import { Grid, Box } from "@mui/material";
import Control from "../../components/controls/Control";
import ClassroomService from "../../service/ClassroomService";

export default function ClassroomForm({
  id,
  loading,
  setLoading,
  setFormSubmitted,
  setCode,
  setPopupClose
}) {


  const initValues = {
    name: "",
  };

  const [formValues, setFormValues] = useState(initValues);

  const validationSchema = Yup.object({
    name: Yup.string().required("Required"),
  });

  const handelSubmit = async (values) => {
    if (validationSchema) {
      if (id) {
        await ClassroomService.update(id, values).then(
          (response) => {
            console.log("update");
            setPopupClose(false);
            setCode();
            
          }
        );
      } else {
        await ClassroomService.create(values).then((response) => {
          console.log("crete");
          setPopupClose(false);
        });
      }
    }
    setFormSubmitted((prev) => prev + 1);
  };

  useEffect(() => {
    if (id != null) {
      getClassByCode(id);
    } else {
      setLoading(true);
    }
  }, [id]);

  const getClassByCode = async (id) => {
    await ClassroomService.getByCode(id)
      .then((response) => {
        setFormValues(response);
        setLoading(true);
      })
      .catch((e) => {
        console.log(e);
      });
  };
 

  return (
    <>
      {loading ? (
        <Formik
          initialValues={formValues}
          validationSchema={validationSchema}
          onSubmit={async (values, onSubmitPros) => {
            await handelSubmit(values);
            onSubmitPros.resetForm();
          }}
        >
          {() => (
            <Form>
              <Box sx={{ flexGrow: 1 }} spacing={2}>
                <Grid container spacing={2}>
                  <Grid item xs={12}>
                    <Control.Input
                      name="name"
                      label="Class Name"
                    />
                  </Grid>
                </Grid>
                <Grid item xs={4}>
                  <Control.Button type="submit" text="Submit" color="success" />
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
