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
import { fetchAcceptedJobs } from "./acceptedJobsSlice";
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

export default function AcceptedJobLists() {
  const classes = useStyles();
  const dispatch = useDispatch();
  const { acceptedJobsLoading, acceptedJobsError, acceptedJobs } = useSelector(state => {
    return {
        acceptedJobsLoading: state.acceptedJobs.loading,
        acceptedJobsError: state.acceptedJobs.error,
      acceptedJobs: state.acceptedJobs.jobs
    };
  }, shallowEqual);

  useEffect(() => {
    if (!acceptedJobs) {
      dispatch(fetchAcceptedJobs());
    }
  }, [acceptedJobs, dispatch]);

  if (acceptedJobsError) {
    return (
      <div>
        <h1>Something went wrong...</h1>
        <div>{acceptedJobsError.error}</div>
      </div>
    );
  }

  let content;

  if (!acceptedJobs) {
    content = (
      <div>
        <p>Loading ...</p>
      </div>
    );
  } else {
    content = (
      <List className={classes.root}>
        {acceptedJobs.lists.map(job => (
          <ListItem>
            <Card className={classes.root} variant="outlined">
              <CardContent>
                <Typography
                  className={classes.title}
                  color="textSecondary"
                  gutterBottom
                >
                  {job.contactFirstName}  {job.contactLastName}{" "}
                  {new Intl.DateTimeFormat("en-AU", {
                    year: "numeric",
                    month: "long",
                    day: "2-digit"
                  }).format(new Date(job.created))}
                </Typography>
                <Typography className={classes.pos} color="textSecondary">
                  {job.suburbName} {job.suburbPostCode} {job.categoryName} Lead Price: $
                  {job.price} discount: ${job.discountAmount} Job Id: {job.id}
                </Typography>
                <Typography className={classes.pos} color="textSecondary">
                  {job.contactPhone} {job.contactEmail} 
                </Typography>
                <Typography variant="body2" component="p">
                  {job.description}
                </Typography>
              </CardContent>              
            </Card>
          </ListItem>
        ))}
      </List>
    );
  }

  return content;
}
