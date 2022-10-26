import React from "react";
import { InputLabel, Select, MenuItem, FormControl } from "@mui/material";
import { Field, ErrorMessage } from "formik";
import Error from "./ErrorMessage";



const SelectBox = (props) => {
  const { name, label, options, ...rest } = props;
  return (

    // <FormControl variant="outlined"  sx={{ minWidth: 270 }} size="small">
    //   <InputLabel >{label}</InputLabel>
    //   <Select {...rest}>
    //     {options &&
    //       options.map((option, index) => (
    //         <MenuItem key={index} value={option.id}>
    //           {option.roomName}
    //         </MenuItem>
    //       ))}
    //   </Select>
    // </FormControl>
    
    <>

<FormControl sx={{minWidth: 250 }} size="small">
        <InputLabel>{label}</InputLabel>
        <Field as={Select} id={name} name={name} {...rest}>
          {options &&
            options.map((option, index) => (
              <MenuItem key={index} value={option.id}>
                {option.name}
              </MenuItem>
            ))}
        </Field>
        </FormControl>
        <ErrorMessage name={name} component={Error} />
    </>
  );
};

export default SelectBox;
