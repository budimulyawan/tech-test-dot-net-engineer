import { createSlice } from '@reduxjs/toolkit'

import {  getAcceptedJobs } from '../../api/hipagesApi'

const initialState = {
  jobs: null,
  loading: false,
  error: null
}

const acceptedJobs = createSlice({
  name: 'acceptedJobs',
  initialState,
  reducers: {
    getAcceptedJobsStart(state) {
      state.loading = true
      state.error = null
      state.jobs = null
    },
    getAcceptedJobsSuccess(state, action) {
      state.jobs = action.payload
      state.loading = false
      state.error = null
    },
    getAcceptedJobsFailure(state, action) {
      state.loading = false
      state.error = action.payload
      state.jobs = null
    },    
  }
})

export const {
    getAcceptedJobsStart,
    getAcceptedJobsSuccess,
    getAcceptedJobsFailure,   
} = acceptedJobs.actions

export default acceptedJobs.reducer

export const fetchAcceptedJobs = () => async dispatch => {
  try {
    dispatch(getAcceptedJobsStart())
    const jobs = await getAcceptedJobs()
    dispatch(getAcceptedJobsSuccess( jobs ))
  } catch (err) {
    dispatch(getAcceptedJobsFailure(err))
  }
}
