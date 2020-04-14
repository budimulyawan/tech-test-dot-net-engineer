import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemText from "@material-ui/core/ListItemText";
import ListItemAvatar from "@material-ui/core/ListItemAvatar";
import Avatar from "@material-ui/core/Avatar";
import ImageIcon from "@material-ui/icons/Image";
import WorkIcon from "@material-ui/icons/Work";
import BeachAccessIcon from "@material-ui/icons/BeachAccess";
import { useSelector, useDispatch, shallowEqual } from "react-redux";
import { fetchNewJobs, submitUpdateJob } from "./newJobsSlice";
import Card from "@material-ui/core/Card";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";

const useStyles = makeStyles(theme => ({
  root: {
    width: "100%",
    backgroundColor: theme.palette.background.paper
  }
}));

export default function NewJobLists() {
  const classes = useStyles();
  const dispatch = useDispatch();
  const { newJobsLoading, newJobsError, newJobs } = useSelector(state => {
    return {
      newJobsLoading: state.newJobs.loading,
      newJobsError: state.newJobs.error,
      newJobs: state.newJobs.jobs
    };
  }, shallowEqual);

  useEffect(() => {
    if (!newJobs) {
      dispatch(fetchNewJobs());
    }
  }, [newJobs, dispatch]);

  if (newJobsError) {
    return (
      <div>
        <h1>Something went wrong...</h1>
        <div>{newJobsError.error}</div>
      </div>
    );
  }

  let content;

  if (!newJobs) {
    content = (
      <div>
        <p>Loading ...</p>
      </div>
    );
  } else {
    content = (
      <List className={classes.root}>
        {newJobs.lists.map(job => (
          <ListItem>
            <Card className={classes.root} variant="outlined">
              <CardContent>
                <Typography
                  className={classes.title}
                  color="textSecondary"
                  gutterBottom
                >
                  {job.contactFirstName}{" "}
                  {new Intl.DateTimeFormat("en-AU", {
                    year: "numeric",
                    month: "long",
                    day: "2-digit"
                  }).format(new Date(job.created))}
                </Typography>
                <Typography className={classes.pos} color="textSecondary">
                  {job.suburbName} {job.suburbPostCode} {job.categoryName} $
                  {job.price} Job Id: {job.id}
                </Typography>
                <Typography variant="body2" component="p">
                  {job.description}
                </Typography>
              </CardContent>
              <CardActions>
                <Button
                  size="small"
                  variant="contained"
                  onClick={submitUpdateJob(job, "Declined")}
                >
                  Decline
                </Button>
                <Button
                  size="small"
                  variant="contained"
                  color="primary"
                  onClick={() => dispatch(submitUpdateJob(job, "Accepted"))}
                >
                  Accept
                </Button>
              </CardActions>
            </Card>
          </ListItem>
        ))}
      </List>
    );
  }

  return content;
}
