import axios from 'axios'

export async function getNewJobs() {
    const url = `https://localhost:5001/api/newjobs`
      const { data } = await axios.get(url)
      return data
  }

  export async function updateJob(job, jobStatus) {
    const url = `https://localhost:5001/api/newjobs/${job.id}`
      const { data } = await axios.put(url,{'id':job.id , 'jobStatus':jobStatus})
      return data
  }
  
  export async function getAcceptedJobs() {
    const url = `https://localhost:5001/api/acceptedjobs`
    const { data } = await axios.get(url)
    return data
  }

  