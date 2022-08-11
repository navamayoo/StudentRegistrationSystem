import axios from "axios";
const API_URL = process.env.REACT_APP_API_URL;

class ClassroomService{

    create = async(classroom)=>{
      await axios({
          method:"Post",
          url:`${API_URL}Class`,
          data:classroom
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
                url:`${API_URL}Class`
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
                url:`${API_URL}Class/${code}`
            });
            return response.data
        }catch(e){
            throw e.message;
        };
        
    }
    update = async(code,classroom)=>{
        await axios({
            method:"PUT",
            url:`${API_URL}Class/${code}`,
            data:classroom,
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
                url:`${API_URL}Class/${code}`
            });
            return response.data
        }catch(e){
            throw e.message;
        };
        
    }
}

export default new ClassroomService();