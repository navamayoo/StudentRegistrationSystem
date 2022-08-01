import axios from "axios";
const API_URL = process.env.REACT_APP_API_URL;

class SubjectService{

    create = async(subject)=>{
      await axios({
          method:"Post",
          url:`${API_URL}Subject`,
          data:subject
      }).catch((e)=>{
          const {message}= e.response.data;
          if(message.errorInfo) throw message.errorInfo[2];
          else throw e.message;
      });
    };

    getAll = async()=>{
        try{
            const response = await axios({
                method:"GET",
                url:`${API_URL}Subject`
            });
            return response.data
        }catch(e){
            throw e.message;
        };
    }

    getByCode = async(code)=>{
        try{
            const response = await axios({
                method: "GET",
                url:`${API_URL}Subject/${code}`
            });
            return response.data
        }catch(e){
            throw e.message;
        };
        
    }
    update = async(code,subject)=>{
        await axios({
            method:"PUT",
            url:`${API_URL}Subject/${code}`,
            data:subject,
        }).catch((e)=>{
            const{message} = e.response.data;
            if(message.errorInfo) throw message.errorInfo[2];
            else throw e.message;
        });
    };
    delete = async(code)=>{
        try{
            const response = await axios({
                method: "DELETE",
                url:`${API_URL}Subject/${code}`
            });
            return response.data
        }catch(e){
            throw e.message;
        };
        
    }
}

export default new SubjectService();