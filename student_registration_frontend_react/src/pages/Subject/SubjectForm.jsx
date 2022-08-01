import React, { useState, useEffect } from "react";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import { Grid, Box } from "@mui/material";
import Control from "../../components/controls/Control";
import SubjectService from "../../service/SubjectService";

export default function SubjectForm({
  id,
  loading,
  setLoading,
  setFormSubmitted,
  setCode,
  setPopupClose
}) {


  const initValues = {
    subjectName: "",
  };

  const [formValues, setFormValues] = useState(initValues);

  const validationSchema = Yup.object({
    subjectName: Yup.string().required("Required"),
  });

  const handelSubmit = async (values) => {
    if (validationSchema) {
      if (id) {
        await SubjectService.update(id, values).then(
          (response) => {
            console.log("update");
            setPopupClose(false);
            setCode();
            
          }
        );
      } else {
        await SubjectService.create(values).then((response) => {
          console.log("crete");
          setPopupClose(false);
        });
      }
    }
    setFormSubmitted((prev) => prev + 1);
  };

  useEffect(() => {
    if (id != null) {
      getSubjectByCode(id);
    } else {
      setLoading(true);
    }
  }, [id]);

  const getSubjectByCode = async (id) => {
    await SubjectService.getByCode(id)
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
                      name="subjectName"
                      label="Subject Name"
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
