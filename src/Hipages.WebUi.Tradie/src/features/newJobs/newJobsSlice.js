import { createSlice } from '@reduxjs/toolkit'

import {  getNewJobs, updateJob } from '../../api/hipagesApi'

const initialState = {
  jobs: null,
  loading: false,
  error: null
}

const newJobs = createSlice({
  name: 'newJobs',
  initialState,
  reducers: {
    getNewJobsStart(state) {
      state.loading = true
      state.error = null
      state.jobs = null
    },
    getNewJobsSuccess(state, action) {
      state.jobs = action.payload
      state.loading = false
      state.error = null
    },
    getNewJobsFailure(state, action) {
      state.loading = false
      state.error = action.payload
      state.jobs = null
    },
    updateNewJobsStart(state) {
      state.loading = true
      state.error = null
      state.jobs = null
    },
    updateNewJobsSuccess(state, action) {
      state.jobs = action.payload
      state.loading = false
      state.error = null
    },
    updateNewJobsFailure(state, action) {
      state.loading = false
      state.error = action.payload
      state.jobs = null
    }
  }
})

export const {
    getNewJobsStart,
    getNewJobsSuccess,
    getNewJobsFailure,
    updateNewJobsStart,
    updateNewJobsSuccess,
    updateNewJobsFailure
} = newJobs.actions

export default newJobs.reducer

export const fetchNewJobs = () => async dispatch => {
  try {
    dispatch(getNewJobsStart())
    const jobs = await getNewJobs()
    dispatch(getNewJobsSuccess( jobs ))
  } catch (err) {
    dispatch(getNewJobsFailure(err))
  }
}

export const submitUpdateJob = (job, status) => async dispatch => {
  try {
    dispatch(updateNewJobsStart())
    await updateJob(job,status)
    const jobs = await getNewJobs()
    dispatch(updateNewJobsSuccess( jobs ))
  } catch (err) {
    dispatch(updateNewJobsFailure(err))
  }
}