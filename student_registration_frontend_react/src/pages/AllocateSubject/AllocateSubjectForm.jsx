
import React, { useEffect, useState } from "react";
import Control from "../../components/controls/Control";
import TeacherService from "../../service/TeacherService";



function AllocateSubjectForm() {

  // const initValues = {
  //   name: "",
  // };
  
  const [teachers, setTeachers]= useState([]);

const getTeachers = async()=>{
  await TeacherService.getAll()
  .then((response)=>{
    setTeachers(response);
  }).catch((e)=>{
    console.log(e);
  });
}
 
useEffect(()=>{
  getTeachers();
},[]);

  return (
  <>  
  
  
  {/* <Paper sx={{p: '100px', borderRadius: '20px', borderColor: 'green'}} variant="outlined">   </Paper>    */}

  <div>
      <form>
      <fieldset> <legend>Teacher Details</legend>

         <label>
           <p>Name</p>
           <input name="name" />
         </label>
         <button type="submit">Submit</button>
         <div>
           <Control.SelectBox
         label="Teacher"
         optional={teachers}
         name="TeacherId"
         />
         </div>
        
       </fieldset>
       
      </form>
    </div>   
 


                

          

    </>

  )
}

export default AllocateSubjectForm