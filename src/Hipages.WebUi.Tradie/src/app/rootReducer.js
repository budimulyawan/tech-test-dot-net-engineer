import { combineReducers } from '@reduxjs/toolkit'

import newJobsReducer from '../features/newJobs/newJobsSlice'
import acceptedJobsReducer from '../features/acceptedJobs/acceptedJobsSlice'


const rootReducer = combineReducers({
  newJobs: newJobsReducer,
  acceptedJobs: acceptedJobsReducer,  
})

export default rootReducer
